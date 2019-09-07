import { IKeyValuePair } from '../../pages/shared/key-value-pair.model';

export interface IAuthUser {
    id: string;
    fullName: string;
    userName: string;
    email: string;
    userRolePermissions: string[];
    imageFile: string;
    token?: string;
}

export interface ILoginUser {
    userName: string;
    password: string;
    rememberMe: boolean;
}

