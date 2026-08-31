objects = [
    "prospects",
    "contacts",
    "comptes",
    "opportunites",
    "appels",
    "reunions",
    "taches",
    "notes",
    "emails",
    "campagnes",
    "utilisateurs",
    "roles"
]
with open('./abstractcrud.txt', 'r') as file:
    contents = file.read()
    for _object in objects:
        tmp_content = contents.replace('OBJECTXYZ', _object)
        print(tmp_content)
        print('================')
