export interface Customer {
    Id?: number;
    firstName: string;
    lastName: string;
    email: string;
    birthdate: Date;
    phone: string;
    repairOrders?: RepairOrder[];
}

export interface ApplicationUser {
    Id: string;
    userName: string;
    email: string;
    phoneNumber: string;
    password: string
    repairOrders: RepairOrder[];
}
export interface RegisterModel {
    userName: string;
    email: string;
    phoneNumber: string;
    password: string;
    userRole: number;
}

export interface RepairOrder {
    id?: string;
    customerId?: string;
    customer?: Customer
    deviceId?: string;
    salesStagesId: string;
    salesStages: SalesStages;
    description: string;
    created: Date;
    updated: Date;
    device?: Device;
    partsUsed?: InventoryItem[];
    applicationUserId?: string;
    applicationUser?: ApplicationUser;
    price: number;
    repairWorks?:RepairWork[];
    loyaltyDiscount:boolean;
    advertisingСompan?:AdvertisingСompany;
    birthdayLoyaltyDiscount?:boolean;
    isWithLoyaltyDiscount?:boolean
}

export interface InventoryItem {
    id: string;
    name: string;
    description: string;
    price: number;
    picture: string;
    quantityInStock: number;
}

export interface Device {
    Id: number;
    name: string;
    manufacturer: string;
    modelDevice: string;
    serialNumber: string;
}

export interface RepairWork {
    id: number;
    name: string;
    description: string;
    price: number;
    //repairOrders: RepairOrder[];
}

export enum Role {
    Administrator,
    ServiceManager,
    Technician,
    ITSupport,
    Executive
}

export enum StatusRepair {
    Success,
    InWork,
    Queued
}

export interface SalesStages{
    id:string;
    name:string;
    orders: RepairOrder[];
    isFirstDefault:boolean;
    isLastDefault:boolean;
    isCancelDefault:boolean;
}

export interface AdvertisingСompany{
    id?:string;
    name:string;
    discount:number;
    description:string;
    code:string;
    repairOrders?:RepairOrder[];
}