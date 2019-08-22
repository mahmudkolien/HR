
export class Shared {

  public readonly PAGE_SIZE = 5;

  toQueryString(obj) {
    // tslint:disable-next-line: prefer-const
    let parts = [];
    // tslint:disable-next-line: forin
    for (const property in obj) {
      const value = obj[property];
      if (value != null && value !== undefined) {
        parts.push(encodeURIComponent(property) + '=' + encodeURIComponent(value));
      }
    }

    return parts.join('&');
  }

  toFormData(obj) {
    // tslint:disable-next-line: prefer-const
    let formData = new FormData();
    // tslint:disable-next-line: forin
    for (const property in obj) {
      const value = obj[property];
      if (value != null && value !== undefined) {
        formData.append(property, value);
      }
    }

    return formData;
  }
}
