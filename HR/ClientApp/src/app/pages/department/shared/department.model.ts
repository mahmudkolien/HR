import { IEntity } from '../../shared/entity.model';
import { IAuditable } from '../../shared/auditable.model';

export interface IDepartment extends IEntity, IAuditable {
    departmentName:string;
}

export class ISaveDepartment{
    id: string;
    isDeleted: boolean;
    departmentName:string;
}