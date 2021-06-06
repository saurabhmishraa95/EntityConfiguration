# EntityConfiguration
Assignment Description:

Created using .Net Core v2.1, it has 2 endpoints for getting ((get)https://localhost:44307/api/configuration) and storing ((put)https://localhost:44307/api/configuration)
configuration in specified json format. For database table, have created only single entity Color (EntityName) due to time constraint I had. In case of source api for field names
created two mock server using postman for Default and Custom fields resp. Used data annotation for validation (can be improved by using fluent validation), used built in 
exception handling middleware as a centralized exception handling machenism (can be improved further), used nunit for testing.
Altogether project can be improved a lot in terms of functionality, scalability and clean coding practices, but due to some time crunch had to leave it at current structure.

For saving configuration, request body:
{
    "entities": [
        {
            "entityName": "Color",
            "fields": [
                {
                    "field": "White",
                    "isRequired": true,
                    "maxLength": 1
                },
                {
                    "field": "Blue",
                    "isRequired": true,
                    "maxLength": 16
                }
            ]
        }
    ]
}

Response body which getting configuration:
{
    "entities": [
        {
            "entityName": "Color",
            "fields": [
                {
                    "field": "Blue",
                    "isRequired": true,
                    "maxLength": 16,
                    "source": "Default"
                },
                {
                    "field": "Grey",
                    "isRequired": false,
                    "maxLength": 18,
                    "source": "Default"
                },
                {
                    "field": "Black",
                    "isRequired": true,
                    "maxLength": 17,
                    "source": "Custom"
                },
                {
                    "field": "Green",
                    "isRequired": false,
                    "maxLength": 5,
                    "source": "Custom"
                },
                {
                    "field": "Maroon",
                    "isRequired": true,
                    "maxLength": 14,
                    "source": "Custom"
                }
            ]
        }
    ]
}
