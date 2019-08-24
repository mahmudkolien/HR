import { IEntity } from '../../shared/entity.model';
import { IAuditable } from '../../shared/auditable.model';

export interface ICompany extends IEntity, IAuditable {
    companyName:string;
    address :string;
    phone :string;
    fax :string;
    email :string;
    contactPerson :string;
    contactPersonEmail :string;
    contactPersonPhone :string;
    fiscalYearStart :string;
}

export class ISaveCompany{
    id: string;
    companyName:string;
    address :string;
    phone :string;
    fax :string;
    email :string;
    contactPerson :string;
    contactPersonEmail :string;
    contactPersonPhone :string;
    fiscalYearStart :string;
}