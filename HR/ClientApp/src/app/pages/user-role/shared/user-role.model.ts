import { IEntity } from '../../shared/entity.model';
import { IAuditable } from '../../shared/auditable.model';
import { IUserRolePermission } from './user-role-permission.model';
import { IQueryObject } from '../../shared/query-object.model';
import { IKeyValuePair } from '../../shared/key-value-pair.model';

export interface IUserRole extends IEntity, IAuditable {
    roleName: string;
    userRolePermissions: IKeyValuePair[];
}

export interface ISaveUserRole extends IEntity {
    roleName: string;
    userRolePermissions: string[];
}

export interface IUserRoleQuery extends IQueryObject {
    name: string;
}

