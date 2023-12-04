# Sorted Coding Test

Test project to read data from the UK Environment Agency Rainfall API.
.Net version - 6

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
