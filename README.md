# PaintStore

PaintStore is a portal that allows to share work with others and look for advice or evaluate and comment on the work of others. Users can follow favourite artists to find their work easier. Everyone has their own profile where they can introduce themselves and put in their work. 

The portal contains also an images finder. Images are searched by tags or title or sorted according to their popularity or date of adding.

[Demo - app]( http://paint-store.azurewebsites.net/homepage)

![alt text](https://raw.githubusercontent.com/wjankowska/screenshots/master/paintstore1.PNG)

Authors
=====

Front-end and Designer
-

[@Weronika Jankowska]( https://github.com/wjankowska)

Back-end and Architect
-

[@Wojciech Rak]( https://github.com/wojtek-rak)

Description
=====

|Version|Quality|Coverage|State|
|---|---|---|---|
|![alt text](https://img.shields.io/badge/version-2.0.0-brightgreen.svg) |[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=wojtek-rak_PaintStore_BackEnd&metric=alert_status)](https://sonarcloud.io/dashboard?id=wojtek-rak_PaintStore_BackEnd)|[![alt text](https://img.shields.io/badge/Coverage-63.6%25-red.svg)](https://sonarcloud.io/component_measures?id=wojtek-rak_PaintStore_BackEnd&metric=coverage)| ![alt text](https://img.shields.io/badge/state-in%20development-red.svg)|


Project was made with Angular 6 and ASP.NET Core 2.2

Full endpoint docs: [docs-paintstore.azurewebsites.net/swagger](https://docs-paintstore.azurewebsites.net/swagger)
Currently disabled


To configure:
-------
Add appsettings.json file with this text,
```json
{  
   "ConnectionStrings":{  
      "PaintStoreDatabase":"(your_conection_string)"
   },
   "AppIdentitySettings":{  
      "CouldName":"(your_CouldName)",
      "ApiKey":"(your_ApiKey)",
      "SecretApiKey":"(your_SecretApiKey)"
   },
   "Logging":{  
      "IncludeScopes":false,
      "Debug":{  
         "LogLevel":{  
            "Default":"Warning"
         }
      },
      "Console":{  
         "LogLevel":{  
            "Default":"Warning"
         }
      }
   }
}
```

[![HitCount](http://hits.dwyl.io/wojtek-rak/PaintStore.svg)](http://hits.dwyl.io/wojtek-rak/PaintStore)

