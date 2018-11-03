# PaintStore_backEnd

![alt text](https://img.shields.io/badge/version-1.0.1-brightgreen.svg) 
![alt text](https://img.shields.io/badge/state-in%20development-red.svg)


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
TypeOfRequest:    Link to request
Input data type:  Data name (application/json)
Output:           Data type (application/json)
```
Search
------
#### Get Search (sorted by indexer)
```
GET Request:  api/Search/{searchWord} 
Input:        string 
Output:       SearchResult  
```
Comments
------
#### Get image's comments (sorted by likes)
```
GET Request:  api/Comments/{postId}
Input:        int 
Output:       PostCommentsResult 
```
#### Add comment
```
POST Request: api/Comments/AddPostComment 
Input:        PostComment 
Output:       PostComments 
```
#### Edit comment
```
PUT Request:  api/Comments/EditPostComment
Input:        PostComment (ID and content)
Output:       PostComment 
```
#### Remove comment (whole)
```
DELETE Request: api/Comments/DeletePostComment/{commentId}
Input:          int
Output:         PostComment 
```
Images
------
#### Upload image to cloudinary
```
POST Request: api/UploadImage
Input:        Image file
Output:       Image (with properties from Models/UploadModels
```
#### Get Post
```
GET Request:  api/Posts/{postId}
Input:        int
Output:       PostDetailsResult
```
#### Get Post from follows (newest)
```
GET Request:  api/Posts/{userId}/GetFollowingPosts
Input:        int
Output:       PostsResult
```
#### Add Post
```
POST Request:  api/Posts/AddPost
Input:         Post 
Output:        Post 
```
#### Remove Post (whole)
```
DELETE Request: api/Posts/DeletePost/{postId}
Input:          int
Output:         Post 
```
#### Edit Post
```
PUT Request:   api/Posts/EditPost
Input:         Post (ID, and prop you want edit, (you can edit: Title, Description, CategoryToolId, CategoryTypeId))
Output:        Post 
```
#### Get all posts
```
PostRequest: api/Posts/AllPosts/{message}
```
+ the newest </br>
```
Input:       string message = "the_newest"
Output:      PostsResult
```
+ most popular </br>
```
Input:       string message = "most_popular"
Output:      PostsResult 
```
#### Get Posts by category
```
PostRequest: api/Posts/AllPosts/{message}/{name}
```
+ tool category </br>
```
Input:  string message = "tool"  
        string name = CategoryTool Name 
Output: PostsResult with given category 
```
+ type category </br>
```
Input:  string message = type"
        string name = CategoryType Name
Output: PostsResult with given category 
```

```
PostRequest: api/Posts/AllPosts/{message}/{typeName}/{toolName}
```
+ both category </br>
```
Input:  string message = "both" 
        string typeName = CategoryType Name 
        string toolName = CategoryTool Name 
Output: PostsResult with given categories 
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

