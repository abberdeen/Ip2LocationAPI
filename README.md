# Ip2LocationAPI
Web-сервис для определения географического местоположения пользователя по IP адресу.
●	Сервис регулярно обновляет базу, используя данные поставщика MaxMind GeoLite2: https://dev.maxmind.com/geoip/geoip2/geolite2/.
●	Сервис имеет REST API для получения географического местоположения (в формате JSON) по заданному IP адресу.
● Задача обновления базы данных реализована в виде консольного приложения .NET Core - Ip2LocationUpdater.
●	REST API реализовано на C#/ASP.NET Core Web API.


## Содержание

<!-- toc --> 
- [Routes](#routes)
- [Worker service](#worker-service)
- [License](#license)
<!-- tocstop -->
 
## Routes

#### Получение географического местоположения (в формате JSON) по заданному IP адресу.
```
POST /api/geolocations
```
Пример POST запроса:
```
{
  "ip": "12.3.4.5"
}
```

## Ip2LocationUpdater
Обновляет базу данных регулярно, используя данные поставщика MaxMind GeoLite2 

## License
MIT

