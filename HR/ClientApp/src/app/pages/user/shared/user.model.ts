import { IEntity } from '../../shared/entity.model';
import { IAuditable } from '../../shared/auditable.model';

export interface IUser extends IEntity, IAuditable {
    fullName: string;
    userName: string;
    email: string;
}

export interface ISaveUser extends IEntity {
    fullName: string;
    userName: string;
    email: string;
    userRoleId: string;
}
