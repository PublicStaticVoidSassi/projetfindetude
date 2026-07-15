tables = [
    {"lead": [
        # "Id"  ,
        "FirstName",
        "LastName",
        "Description",
        "Status",
        "Source",
        "Phone",
        "Email",
        # "UserID" ,
        # "AccountID" ,
    ]},
    {"contact": [
        # "Id" ,
        "FirstName",
        "MiddleName",
        "LastName",
        "Description",
        "Status",
        "Source",
        "Phone",
        "Fax",
        "Email",
        "Website",
        "Street",
        "City",
        "Country",
        "PostalCode",
        "Job",
        "Department",
        # "AccountID" ,
        # "LeadID" ,
        # "UserID" ,
    ]},
    {"opportunity": [
        # "Id"  ,
        "Name",
        "Description",
        "AmountValue",
        "AmountCurrency",
        "Stage",
        "Type",
        "Probability",
        "NextStep",
        "ClosedAt",
        # "AccountID" ,
        # "ContactID" ,
        # "LeadID" ,
        # "OwnerID" ,
    ]},
    {"call": [
        # "Id"  ,
        "Name",
        "Description",
        "Status",
        "Direction",
        "StartTime",
        "EndTime",
        "Duration",
        "PhoneNumber",
        # "AccountID" ,
        # "ContactID" ,
        # "OpportunityID",
        # "LeadID" ,
        # "OwnerID" ,
    ]},
    {"task": [
        # "Id"  ,
        "Name",
        "Description",
        "Status",
        "Priority",
        "StartTime",
        "EndTime",
        "CompletedAt",
        # "AccountID" ,
        # "ContactID" ,
        # "OpportunityID",
        # "LeadID" ,
        # "OwnerID" ,
    ]},
    {"meeting": [
        # "Id"  ,
        "Name",
        "Description",
        "Status",
        "StartTime",
        "EndTime",
        "Location",
        # "AccountID" ,
        # "ContactID" ,
        # "OpportunityID",
        # "LeadID" ,
        # "OwnerID" ,
    ]},
    {"email": [
        # "Id" ,
        "Subject",
        "Body",
        "Status",
        "From",
        "To",
        "Cc",
        "Bcc",
        "SentAt",
        "IsHtml",
    ]},
    {"note": [
        # "Id"  ,
        "Title",
        "Content",
        "Type",
        # "AccountID" ,
        # "ContactID" ,
        # "OpportunityID",
        # "LeadID" ,
        # "OwnerID" ,
    ]},
    {
        "account":
        [
            # "Id",
            "Name",
            "Description",
            "Phone",
            "Fax",
            "Email",
            "Website",
            "Street",
            "City",
            "Country",
            "PostalCode",
            "Type",
            "Industry",
            "IncomeValue",
            "IncomeCurrency",
            "Employees",
            # "UserID"
        ]
    }
]

INCLUDE_AUDIT = False
INCLUDE_FRAMEWORK = False
default_size = 255
default_nature = "AN"
code = 1
for table in tables:
    for table_name, table_cols in table.items():
        for col in table_cols:
            print(f"|{code}|{table_name}_{col}|{table_name} {col}| {default_nature} | E | {default_size} | {
                  (lambda col: "aaaa/mm/jj hh:MM:ss" if "date" in col.lower() or "time" in col.lower() else "")(col)}|")
            code += 1
        if INCLUDE_FRAMEWORK:
            for col in ["ExtraProperties", "ConcurrencyStamp"]:
                print(f"|{code}|{table_name}_{col}|{table_name} {col}| {default_nature} | {default_size} | {
                      (lambda col: "aaaa/mm/jj hh:MM:ss" if "date" in col.lower() or "time" in col.lower() else "")(col)}|")
                code += 1
        if INCLUDE_AUDIT:
            for col in ["CreationTime", "CreatorId", "LastModificationTime", "LastModifierId", "IsDeleted", "DeleterId", "DeletionTime"]:
                print(f"|{code}|{table_name}_{col}|{table_name} {col}| {default_nature} | {default_size} | {
                      (lambda col: "aaaa/mm/jj hh:MM:ss" if "date" in col.lower() or "time" in col.lower() else "")(col)}|")
                code += 1

# for i in range(1+source, len(cols)+source):
#     print(f"|{i}|{table_name}{cols[i]}|{table_name} {cols[i]}| A | 255 |  |")
