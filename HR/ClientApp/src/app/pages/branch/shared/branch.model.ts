import { IEntity } from '../../shared/entity.model';
import { IAuditable } from '../../shared/auditable.model';
import { ICompany } from '../../company/shared/company.model';
import { IKeyValuePair } from '../../shared/key-value-pair.model';

export interface IBranch extends IEntity, IAuditable {
     company:IKeyValuePair;
     branchName :string;
     address :string;
     phoneNo:string;
     email:string;
}

export class ISaveBranch{
    id: string;
    companyId:string;
    branchName :string;
    address :string;
    phoneNo:string;
    email:string;
}