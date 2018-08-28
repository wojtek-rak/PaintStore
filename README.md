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
PostRequest:      Link to postrequest
Input data type:  Data name (application/json)
Output:           Data type (application/json)
```

Comments
------
#### Get image's comments
```
PostRequest:  api/CommentsGet 
Post:         ImgLink 
Output:       PostComments 
```
#### Add comment
```
PostRequest:  api/CommentAdd 
PostComment:  PostComment 
Output:       PostComments 
```
Images
------
#### Upload image to cloudinary
```
PostRequest:  api/UploadImage
Image:        Image file
Output:       Image (with properties from Models/UploadModels
```
#### Get Post
```
PostRequest:   api/ImageGet
Post:  ImgLink
Output: Post
```
#### Add Post
```
PostRequest:   api/AddImage
Post:          Post 
Output:        Post 
```
#### Get all posts
```
PostRequest: api/ImagesAllGet
```
+ the newest </br>
```
Message Properties: "the_newest"
Output:             Posts
```
+ most popular </br>
```
Message Properties: "most_popular"
Output:              Posts 
```
#### Get Posts by category
```
PostRequest: api/ImagesGetByCategory
```
+ both category </br>
```
Message Properties: "both" 
Message Category_type: CategoryType 
Message Category_tool: CategoryTool 
Output: Posts with given categories 
```
+ tool category </br>
```
Message Properties: "tool" 
Message Category_type: "" 
Message Category_tool: CategoryTool 
Output: Posts with given category 
```
+ type category </br>
```
Message Properties: "type"
Message Category_type: CategoryType
Message Category_tool: "" 
Output: Posts with given category 
```

User
------
#### Get user
```
PostRequest:  api/UserGet
User:         Link
Output:       User 
```
#### Get user's images
```
PostRequest:  api/UserImagesGetController
User:         OwnerPath 
Output:       Images 
```

