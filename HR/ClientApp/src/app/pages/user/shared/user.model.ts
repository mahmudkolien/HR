import { IKeyValuePair } from './../../shared/key-value-pair.model';
import { IEntity } from '../../shared/entity.model';
import { IAuditable } from '../../shared/auditable.model';
import { IQueryObject } from '../../shared/query-object.model';

export interface IUser extends IEntity, IAuditable {
    fullName: string;
    userName: string;
    email: string;
    userRole: IKeyValuePair;
    imageFile: string;
}

export interface ISaveUser extends IEntity {
    fullName: string;
    userName: string;
    email: string;
    userRoleId: string;
    imageFile: string;
    inputFile: File;
}

export interface IUserQuery extends IQueryObject {
    name: string;
}
