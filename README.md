# Sorted Coding Test

Test project to read data from the UK Environment Agency Rainfall API.
.Net version - 6

# Project structure

The following project structure helps us isolate part of the components:

- SortedCodingTest.Api - where our API-related staff is (controllers, request/response models etc.)
- SortedCodingTest.Host - where we place the host configuration (place to configure middlewares, app configuration etc.)
- SortedCodingTest.App - contains logic used to integrate with an external Rainfall API + application level dto’s
- SortedCodingTest.Rainfall.Client - contains logic used to call the Rainfall API.

## Setting Up

To setup this project, you need to clone the git repo

```sh
$ git clone https://github.com/dkarpliuk/sorted-coding-test
$ cd src/SortedCodingTest.Api/
```

followed by

```sh
$ dotnet restore
```

and

```sh
$ dotnet run
```

## Run tests

```sh
$ dotnet test
```

## API description

```http
GET /rainfall/id/{stationId}/readings?maximum=100
```

| Parameter   | Type     | Description                                    |
| :---------- | :------- | :--------------------------------------------- |
| `stationId` | `string` | **Required**. Station ID                       |
| `maximum`   | `int`    | **Required**. Limit of measures (max - 10000)  |

## Response

```javascript
{
  "readings": [{
            "dateMeasured": string,
            "amountMeasured": number
        }]
}
```

## Swagger Doc

{API_HOST}/swagger/index.html
