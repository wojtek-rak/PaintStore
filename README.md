# PaintStore_backEnd

Api for database support, and uploading images to Cloudinary

To configure:
-------
Add appsettings.json file with this text,
```json
    
 {
  "ConnectionStrings": {
    "PaintStoreDatabase": "(your_conection_string)"
  },
  "AppIdentitySettings": {
    "CouldName": "(your_CouldName)",
    "ApiKey": "(your_ApiKey)",
    "SecretApiKey": "(your_SecretApiKey)",
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
Input data type:  Data name (application/json)
Output:           Data type (application/json)
```
Comments
------
#### Get image's comments
```
Post:   api/CommentsGet 
Image: ImgLink 
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
#### Upload image to cloudinary
```
Post:   api/UploadImage
Image:  Image file
Output: Image (with properties from Models/UploadModels
```
#### Get image
```
Post:   api/ImageGet
Image:  ImgLink
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
Message Properties: "the_newest"
Output: Images
```
+ most popular </br>
```
Message Properties: "most_popular"
Output: Images 
```
#### Get images by category
```
Post: api/ImagesGetByCategory
```
+ both category </br>
```
Message Properties: "both" 
Message Category_type: category_type 
Message Category_tool: category_tool 
Output:  Images with given categories 
```
+ tool category </br>
```
Message Properties: "tool" 
Message Category_type: "" 
Message Category_tool: category_tool 
Output:  Images with given category 
```
+ type category </br>
```
Message Properties: "type"
Message Category_type: category_type
Message Category_tool: "" 
Output:  Images with given category 
```

User
------
#### Get user
```
Post:   api/UserGet
User: Link
Output: User 
```
#### Get user's images
```
Post:   api/UserImagesGetController
User: OwnerPath 
Output: Images 
```

