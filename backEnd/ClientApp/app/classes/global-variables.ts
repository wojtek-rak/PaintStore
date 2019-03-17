export abstract class GlobalVariables {
  private static _key = "id";
    private static _host = "http://paint-store.azurewebsites.net/";

  public static get key() {
    return this._key;
  }

  public static get host() {
    return this._host;
  }

  public static parseTags(tags: any): string[] {
    let newTags = [];

    if (tags !== [] && tags !== "" && tags !== null) {
      tags.forEach(el => {
        newTags.push(el.value);
      });
    }
    return newTags;
  }
}
