import requests

API_KEY = 'd1fc5502f53623c5b67189496271e510e8f78067f5bc9fff99ca08055ef543b7'

def upload_file(path):
    url = "https://www.virustotal.com/api/v3/files"

    files = { "file": (path, open(path, "rb"))}
    headers = {
        "accept": "application/json",
        "x-apikey": API_KEY
    }

    response = requests.post(url, files=files, headers=headers)

    return response.json()['data']['links']['self']

def get_info_file(path):
    url = upload_file(path)

    headers = {
        "accept": "application/json",
        "x-apikey": API_KEY
    }

    response = requests.get(url, headers=headers)
    return response.json()['data']['attributes']['results']

def print_info(dictionary):
    for name in dictionary:
        print('Антивирус:', name)
        print('Результат:', dictionary[name]['result'])
        print('\n')
