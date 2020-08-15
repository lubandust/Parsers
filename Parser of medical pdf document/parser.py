from sys import argv

from tika import parser
from bs4 import BeautifulSoup
import os


def get_pdf(folder_name, what_to_get):
    try:
        for file in os.listdir(folder_name):
            print(folder_name)
            print(file)
            if file.endswith(".pdf"):
                name, ext = os.path.splitext(os.path.basename(file))
                print(name)
                if what_to_get == "Неотложная помощь" or what_to_get == "Диагностика":
                    parse(os.path.join(folder_name, file), what_to_get, name)
                else:
                    break
    except FileNotFoundError:
        print("Папка не существует")


def write_to_db(parsed_info, what_to_get, name):
    print(parsed_info)
    file_name = name + ".txt"
    f = open(file_name, 'w')
    f.write(parsed_info)
    f.close()
    #если баз недоступна, то исключение

def parse(pdf_name, what_to_get, name):
    print(what_to_get)
    if what_to_get=="Диагностика":
        search_str = ["диагности", "характерист"]
    if what_to_get=="Неотложная помощь":
        search_str = ["лечение", "неотложная помощь", "помощ"]

    p_list = []
    contents_list = []
    start = ""
    end = ""

    extracted_text = parser.from_file(pdf_name, xmlContent=True)
    soup = BeautifulSoup(extracted_text["content"], 'lxml')

    for p in soup.find_all("p"):
        if len(p) > 0:
            p_list.append(p.contents[0])

    Ultag = soup.find("ul")

    for li in Ultag.find_all("li"):
        contents_list.append(li.contents[0])

    for i in range(len(contents_list)):
        for j in range(len(search_str)):
            if search_str[j] not in contents_list[i].lower():
                continue
            else:
                start = contents_list[i]
                print(start)
                i = i + 1
                while not end:
                    try:
                        if (contents_list[i][0].isdigit() and contents_list[i][1] == '.' and contents_list[i][
                            2].isdigit() == False and start[0].isdigit()) or \
                                (contents_list[i][0].isdigit() == False and start[0].isdigit() == False):
                            end = contents_list[i]
                            break
                        else:
                            i = i + 1
                    except IndexError:
                        end = contents_list[len(contents_list) - 1]
                        print(end)
                break

    start = ''.join(start.split())
    end = ''.join(end.split())
    index_start = 0
    index_end = len(p_list)

    for i in range(len(p_list) - 1):
        line = str(p_list[i] + p_list[i + 1].lower())
        line = ''.join(line.split())
        if start.lower() in line:
            index_start = i
        if end.lower() in line:
            index_end = i

    if index_start==0 and index_end==len(p_list):
        print("Раздел", what_to_get,  "отсутствует: в базу даных будет занесен весь текст документа")
    try:
        n = p_list[index_start:index_end]
        fin = ''.join(n)
        if fin=="":
            fin = ''.join(p_list)
    except ValueError:
        print("Раздел", what_to_get,  "отсутствует: в базу даных будет занесен весь текст документа")
        fin = ''.join(p_list)
    finally:
        write_to_db(fin, what_to_get, name)


if __name__ == '__main__':
    try:
        option_to_unpack, pdf_dir, what_to_get = argv
        get_pdf(pdf_dir, what_to_get)
    except ValueError:
        print("Неверное количество аргументов: введите команду в виде python parse /home/user/folder")