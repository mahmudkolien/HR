import { IEntity } from '../../shared/entity.model';
import { IAuditable } from '../../shared/auditable.model';

export interface IUser extends IEntity, IAuditable {
    FullName: string;
    UserName: string;
    Email: string;
    Password: string;
}

export interface ISaveUser extends IEntity {
    FullName: string;
    UserName: string;
    Email: string;
    Password: string;
}
