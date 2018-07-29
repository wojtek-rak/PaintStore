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
Comments
------
#### Get image's comments
Post: api/CommentsGet </br>
String: ImgLink </br>
Output: Comments </br>
#### Add comment
Post: api/CommentAdd </br>
Comment: Comment </br>
Output: Comments </br>

Images
------
#### Get image
Post: api/ImageGet </br>
String: ImgLink </br>
Output: Image </br>
#### Add image
Post: api/AddImage </br>
Image: Image </br>
Output: Image </br>
#### Get all images
Post: api/ImagesAllGet </br>
String: "the_newest" </br>
Output: Images </br></br>

String: "most_popular" </br>
Output: Images </br>
#### Get images by category
Post: api/ImagesGetByCategory </br>
String1: "both" </br>
String2: category_type </br>
String3: category_tool </br>
Output: Images with given categories </br></br>

String1: "tool" </br>
String2: "" </br>
String3: category_tool </br>
Output: Images with given category </br></br>

String1: "type" </br>
String2: category_type </br>
String3: "" </br>
Output: Images with given category </br>

User
------
#### Get user
Post: api/UserGet </br>
String: Link </br>
Output: User </br>
#### Get user's images
Post: api/UserImagesGetController </br>
String: OwnerPath </br>
Output: Images </br>

