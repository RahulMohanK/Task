# API Documentation

Secure vision provide endponints for developers. This can be used to integrate Secure Vision into your project.

# Allowed HTTP method

POST    : Add resource \
GET     : Get a resource or list of resources\
PUT     : Update resource \
DELETE  : Delete resource

# API endpoints

## GET STAFF

**URL** : `/Staff/?type={staff_type}/`

**Method** : `GET`




## Success Response

**Condition** : If Staffs exist.

**Code** : `200 OK`

**Content Response Example**

```json
[
     {
        "id": 1122,
        "empId": "admin01",
        "name": "rahul",
        "phone": "+91-78945612",
        "email": "rahul@asd.com",
        "dob": "1999-02-22T00:00:00",
        "staffType": 0,
        "createdDate": "2020-09-02T15:54:40.417",
        "updatedDate": "2020-09-02T15:54:40.417",
        "administrativeStaff": [
            {
                "id": 1055,
                "staffId": 1122,
                "designation": "Clerk"
            }
        ],
        "supportingStaff": [],
        "teachingStaff": []
    },
    {
        "id": 1124,
        "empId": "admin11",
        "name": "rahul",
        "phone": "+91-78945612",
        "email": "rahul@asd.com",
        "dob": "1999-02-22T00:00:00",
        "staffType": 0,
        "createdDate": "2020-09-02T15:56:34.72",
        "updatedDate": "2020-09-02T15:56:34.72",
        "administrativeStaff": [
            null
        ],
        "supportingStaff": [],
        "teachingStaff": []
    }
]
```

## Error Responses

**Condition** : If staff is not found.

**Code** : `404 Not Found` 



## GET STAFF

**URL** : `/Staff/{empID}`

**Method** : `GET`


**Permissions required** : None



## Success Response

**Condition** : If Staff Exist.

**Code** : `200 OK`

**Content Response Example**

```json
{
    "id": 1151,
    "empId": "teach012",
    "name": "rahul",
    "phone": "+91-78945612",
    "email": "rahul@asd.com",
    "dob": "1999-02-22T00:00:00",
    "staffType": 1,
    "createdDate": "2020-09-03T17:42:01.267",
    "updatedDate": "2020-09-03T17:42:01.267",
    "administrativeStaff": [],
    "supportingStaff": [],
    "teachingStaff": [
        {
            "id": 1022,
            "staffId": 1151,
            "subject": "Maths"
        }
    ]
}
```

## Error Responses

**Condition** : If staff not found.

**Code** : `404 Not Found`


## ADD STAFF    

**URL** : `/Staff/`

**Method** : `POST`



**Data Request Format**

Provide the parameters given below.

```json
{
    "name":"rahul",
    "empId":"teach58",
    "staffType":1,
    "email":"rahul@asd.com",
    "phone":"+91-78945612",
    "dob":"1999-02-22T00:00:00",
    "teachingStaff":[{"subject":"Chemistry"}]   
}
```


## Success Response

**Condition** : If empId is unique and corresponding staff list is not empty.

**Code** : `201 Created`

**Content Response Format**

```json
{
    "id": 1156,
    "empId": "teach58",
    "name": "rahul",
    "phone": "+91-78945612",
    "email": "rahul@asd.com",
    "dob": "1999-02-22T00:00:00",
    "staffType": 1,
    "createdDate": "2020-09-03T19:19:03.37",
    "updatedDate": "2020-09-03T19:19:03.37",
    "administrativeStaff": [],
    "supportingStaff": [],
    "teachingStaff": [
        {
            "id": 1025,
            "staffId": 1156,
            "subject": "Chemistry"
        }
    ]
}
```

## Error Responses

**Condition** : If empId is not unique or corresponding Staff list is empty.

**Code** : `400 Bad Request`


## EDIT STAFF

**URL** : `/Staff/{empId}`

**Method** : `PUT`



**Data Request Format**

Provide the parameters given below.

```json
{   
     
    "empId":"suppo55",
    "staffType":2,
    "email":"rahul@rahu.com",
    "phone":"+91-78945612",
    "dob":"1999-02-21",
    "supportingStaff":[{"department":"EEE"}]
    
}
```


## Success Response

**Condition** : If everything is OK and parameters are valid.

**Code** : `200 OK`

**Content Response Format**

```json
{
    "id": 1133,
    "empId": "suppo55",
    "name": "rahul",
    "phone": "+91-78945612",
    "email": "rahul@rahu.com",
    "dob": "1999-02-21T00:00:00",
    "staffType": 2,
    "createdDate": "2020-09-02T20:01:04.243",
    "updatedDate": "2020-09-03T16:39:10.92",
    "administrativeStaff": [],
    "supportingStaff": [
        {
            "id": 39,
            "staffId": 1133,
            "department": "EEE"
        }
    ],
    "teachingStaff": []
}
```

## Error Responses

**Condition** : If empId is not present.

**Code** : `404 Not Found`

## DELETE STAFF

**URL** : `/Staff/{empId}`

**Method** : `DELETE`


## Success Response

**Condition** : If empId is present.

**Code** : `200 OK`

**Content Response Format**

```json
{
    "id": 1133,
    "empId": "suppo55",
    "name": "rahul",
    "phone": "+91-78945612",
    "email": "rahul@rahu.com",
    "dob": "1999-02-21T00:00:00",
    "staffType": 2,
    "createdDate": "2020-09-02T20:01:04.243",
    "updatedDate": "2020-09-03T16:39:10.92",
    "administrativeStaff": [],
    "supportingStaff": [
        {
            "id": 39,
            "staffId": 1133,
            "department": "EEE"
        }
    ],
    "teachingStaff": []
}
```

## Error Responses

**Condition** : If empId not found.

**Code** : `404 Not Found`


