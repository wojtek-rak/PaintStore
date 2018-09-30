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
Search
------
#### Get Search (sorted by indexer)
```
PostRequest:  api/Search 
Input:        Name 
Output:       SearchResult  
```
Comments
------
#### Get image's comments (sorted by likes)
```
PostRequest:  api/CommentsGet 
Input:        Id 
Output:       PostCommentsResult 
```
#### Add comment
```
PostRequest:  api/CommentAdd 
Input:        PostComment 
Output:       PostComments 
```
#### Edit comment
```
PostRequest:  api/CommentEdit
Input:        PostComment (ID and content)
Output:       PostComment 
```
#### Remove comment (whole)
```
PostRequest:  api/CommentRemove
Input:        PostComment (ID)
Output:       PostComment 
```
Images
------
#### Upload image to cloudinary
```
PostRequest:  api/UploadImage
Input:        Image file
Output:       Image (with properties from Models/UploadModels
```
#### Get Post
```
PostRequest:  api/ImageGet
Input:        Id
Output:       PostDetailsResult
```
#### Get Post from follows (newest)
```
PostRequest:  api/ImagesFollowingGet
Input:        ID
Output:       PostsResult
```
#### Add Post
```
PostRequest:   api/ImageAdd
Input:         Post 
Output:        Post 
```
#### Remove Post (whole)
```
PostRequest:  api/ImageRemove
Input:        Post (ID)
Output:       Post 
```
#### Edit Post
```
PostRequest:   api/ImageEdit
Input:         Post (ID, and prop you want edit, (you can edit: Title, Description, CategoryToolId, CategoryTypeId))
Output:        Post 
```
#### Get all posts
```
PostRequest: api/ImagesAllGet
```
+ the newest </br>
```
Input:       Properties "the_newest"
Output:      PostsResult
```
+ most popular </br>
```
Input:       Properties "most_popular"
Output:      PostsResult 
```
#### Get Posts by category
```
PostRequest: api/ImagesGetByCategory
```
+ both category </br>
```
Input:  Properties "both" 
        CategoryType Name 
        CategoryTool Name 
Output: PostsResult with given categories 
```
+ tool category </br>
```
Input:  Properties "tool"  
        CategoryTool Name 
Output: PostsResult with given category 
```
+ type category </br>
```
Input:  Properties "type"
        CategoryType: Name
Output: PostsResult with given category 
```

Account
------
#### Add account
```
PostRequest:  api/AccountAdd
Input:        Account
Output:       Account 
```
#### Edit account
```
PostRequest:  api/AccountEdit
Input:        Account (ID and prop you want to edit (cannot edit CreationDate and id))
Output:       Account 
```
#### Remove account
```
PostRequest:  api/AccountRemove
Input:        Account (ID and passwordHash)
Output:       Account 
```

User
------
#### Get user
```
PostRequest:  api/UserGet
Input:        Id
Output:       UsersResult 
```
#### Get user's images
```
PostRequest:  api/UserImagesGet
Input:        Id 
Output:       Images 
```
#### Add user
```
PostRequest:  api/UserAdd
Input:        User
Output:       User 
```
#### Edit user
```
PostRequest:  api/UserEdit
Input:        User (ID and prop you want to edit (cannot edit account id and id))
Output:       User 
```

Comment Likes
------
#### Get likes
```
PostRequest: api/CommentsLikesGet
Input:       Id
Output:      LikesResult
```
#### Add like
```
PostRequest:    api/CommentLikeAdd
Input:          Comment Like 
Output:         Comment Like 
```
#### Remove like
```
PostRequest:  api/CommentLikeRemove
Input:        Comment Like ( ID )
Output:       Comment Like 
```

Image Likes
------
#### Get likes
```
PostRequest: api/ImageLikesGet
Input:       Id
Output:      LikesResult
```
#### Add like
```
PostRequest: api/ImageLikeAdd
Input:       PostLike 
Output:      PostLike 
```
#### Remove like
```
PostRequest: api/ImageLikeRemove
Input:       PostLike ( ID )
Output:      PostLike
```

Category
------
#### Get, or add and get category
```
PostRequest: api/CategoryGetAdd
Input:       Category: "TypeName" or "ToolName")
Output:      CategoryType or CategoryTool
```

User Followers
------
#### Add Follow
```
PostRequest: api/FollowersAdd
Input:       Follow 
Output:      Follow 
```
#### Remove Follow
```
PostRequest: api/FollowersRemove
Input:       Follow ( ID )
Output:      Follow
```
#### Get Followed
```
PostRequest: api/FollowedGet
Input:       Id 
Output:      LikesResult 
```
#### Get Following
```
PostRequest: api/FollowingGet
Input:       Id 
Output:      LikesResult 
```

Implemented (auto) Countings
------
#### Countings for:
```
Post likes in Post
Comment likes in Comment
Post count in User
Comment count in Post
Followed user in User
Following user in User
CategoryType count in CategoryType
CategoryTool count in CategoryTool
```

