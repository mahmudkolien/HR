import { IEntity } from '../../shared/entity.model';
import { IAuditable } from '../../shared/auditable.model';

export interface IUserRole extends IEntity, IAuditable {
    roleName: string;
}

