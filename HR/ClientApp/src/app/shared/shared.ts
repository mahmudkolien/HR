
import * as _ from 'underscore';

export class Shared {

  public readonly PAGE_SIZE = 5;
  public readonly PhotoSettings = {
    MaxBytes: 2097152, // 2MB=2097152, 3MB=3145728
    AcceptedFileTypes: ['.jpg', '.jpeg', '.png'] ,
  };

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

  getMapValue(collection: Array<any>, property: string) {
    return _.pluck(collection, property);
  }

  hasMatchValue(collection1: Array<any>, collection2: Array<any>) {
    return !_.isEmpty(_.intersection(collection1, collection2));
  }
}
