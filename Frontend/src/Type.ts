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
    customerId?: number;
    customer?:Customer
    deviceId?: number;
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
}

export interface InventoryItem {
    Id?: number;
    name: string;
    description: string;
    price: number;
    picture: string;
    quantityInStock: number;
}

export interface Device {
    Id: number;
    Name: string;
    Manufacturer: string;
    ModelDevice: string;
    SerialNumber: string;
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