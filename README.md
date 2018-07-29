# PaintStore_backEnd
To configure:
-------
Add appsettings.json file with this text,
```json
{
  "ConnectionStrings": {
    "PaintStoreDatabase": "(your_conection_string)"
  },
  "Logging": {
    "IncludeScopes": false,
    "Debug": {
      "LogLevel": {
        "Default": "Warning"
      }
    },
    "Console": {
      "LogLevel": {
        "Default": "Warning"
      }
    }
  }
}
```
Description
=====
```
Post:             Link to post
Input data type:  Data name
Output:           Data type
```
Comments
------
#### Get image's comments
```
Post:   api/CommentsGet 
String: ImgLink 
Output: Comments 
```
#### Add comment
```
Post:     api/CommentAdd 
Comment:  Comment 
Output:   Comments 
```
Images
------
#### Get image
```
Post:   api/ImageGet
String: ImgLink
Output: Image
```
#### Add image
```
Post:   api/AddImage
Image:  Image 
Output: Image 
```
#### Get all images
```
Post: api/ImagesAllGet
```
+ the newest </br>
```
String: "the_newest"
Output: Images
```
+ most popular </br>
```
String: "most_popular"
Output: Images 
```
#### Get images by category
```
Post: api/ImagesGetByCategory
```
+ both category </br>
```
String1: "both" 
String2: category_type 
String3: category_tool 
Output:  Images with given categories 
```
+ tool category </br>
```
String1: "tool" 
String2: "" 
String3: category_tool 
Output:  Images with given category 
```
+ type category </br>
```
String1: "type"
String2: category_type
String3: "" 
Output:  Images with given category 
```

User
------
#### Get user
```
Post:   api/UserGet
String: Link
Output: User 
```
#### Get user's images
```
Post:   api/UserImagesGetController
String: OwnerPath 
Output: Images 
```

