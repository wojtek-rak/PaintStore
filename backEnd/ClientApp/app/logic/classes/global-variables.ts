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
    const newTags = [];

    if (tags !== [] && tags !== "" && tags !== null) {
      tags.forEach(el => {
        newTags.push(el.value);
      });
    }
    return newTags;
  }

  public static parseImageLink(
    w: number,
    h: number,
    link: string,
    mode: string = "c_fill",
    quality: string = "eco"
  ): string {
    if (link === "" || link === null) {
      return null;
    }

    const insertAfter = "http://res.cloudinary.com/dvjarj3xz/image/upload/";
    let toInsert;
    let newLink: string = null;
    toInsert = `w_${w},h_${h},${mode}/q_auto:${quality}/`;
    newLink = [
      link.slice(0, insertAfter.length),
      toInsert,
      link.slice(insertAfter.length)
    ].join("");

    return newLink;
  }
}
