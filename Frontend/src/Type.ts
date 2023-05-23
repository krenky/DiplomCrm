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
    status: StatusRepair;
    description: string;
    created: Date;
    updated: Date;
    startedAt: Date;
    endedAt: Date;
    device?: Device;
    partsUsed?: InventoryItem[];
    applicationUserId?: string;
    applicationUser?: ApplicationUser;
    price: number;
    loyaltyDiscount:boolean;
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