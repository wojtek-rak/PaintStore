export class User {
  _about: string;
  _accountId: number;
  _avatarImgLink: string;
  _backgroundImgLink: string;
  _followedCount: number;
  _followingCount: number;
  _id: number;
  _link: string;
  _mostUsedCategoryToolName: string;
  _name: string;
  _postsCount: number;

  constructor() {
    this._about = "";
    this._accountId = 0;
    this._avatarImgLink = "";
    this._backgroundImgLink = "";
    this._followedCount = 0;
    this._followingCount = 0;
    this._id = 0;
    this._link = "";
    this._mostUsedCategoryToolName = "";
    this._name = "";
    this._postsCount = 0;
  }

  get about() {
    return this._about;
  }
  get accountId() {
    return this._accountId;
  }
  get avatarImgLink() {
    return this._avatarImgLink;
  }
  get backgroundImgLink() {
    return this._backgroundImgLink;
  }
  get followedCount() {
    return this._followedCount;
  }
  get followingCount() {
    return this._followingCount;
  }
  get id() {
    return this._id;
  }
  get link() {
    return this._link;
  }
  get name() {
    return this._name;
  }
  get postsCount() {
    return this._postsCount;
  }
  get mostUsedCategoryToolName() {
    return this._mostUsedCategoryToolName;
  }
}
