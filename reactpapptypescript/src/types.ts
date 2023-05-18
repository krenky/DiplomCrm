import { RaRecord, Identifier } from 'react-admin';

export interface Sale extends RaRecord {
    first_name: string;
    last_name: string;
    email: string;
}

export interface Company extends RaRecord {
    name: string;
    logo: string;
    sector: string;
    size: 1 | 10 | 50 | 250 | 500;
    linkedIn: string;
    website: string;
    phone_number: string;
    address: string;
    zipcode: string;
    city: string;
    stateAbbr: string;
    nb_contacts: number;
    nb_deals: number;
    sales_id: Identifier;
    created_at: string;
}

export interface Contact extends RaRecord {
    first_name: string;
    last_name: string;
    title: string;
    company_id: Identifier;
    email: string;
    avatar?: string;
    first_seen: string;
    last_seen: string;
    has_newsletter: Boolean;
    tags: Identifier[];
    gender: string;
    sales_id: Identifier;
    nb_notes: number;
}

export interface ContactNote extends RaRecord {
    contact_id: Identifier;
    type: string;
    text: string;
    date: string;
    sales_id: Identifier;
    status: string;
}

export interface Deal extends RaRecord {
    name: string;
    company_id: Identifier;
    contact_ids: Identifier[];
    type: string;
    stage: string;
    description: string;
    amount: number;
    created_at: string;
    updated_at: string;
    sales_id: Identifier;
    index: number;
    nb_notes: number;
}

export interface Tag extends RaRecord {
    name: string;
    color: string;
}
export interface Customer extends RaRecord{
    first_name: string;
    last_name: string;
    email: string;
    avatar?: string;
    tags: Identifier[];
    gender: string;
    birthdate: Date;
    phone: string;
    repairOrders: RepairOrders[];
}

export interface RepairOrders extends RaRecord{
    customerId: Identifier;
    deviceId: number;
    status: number;
    description: string;
    created: Date;
    updated: Date;
    partsUsed: InventoryItem[];
    aspNetUserId: string;
}

export interface InventoryItem extends RaRecord{
    name: string;
    description: string;
    price: number;
    picture: string;
    quantityInStock: number;
}

export interface Device extends RaRecord {
    Name: string;
    Manufacturer: string;
    ModelDevice: string;
    SerialNumber: string;
}

export enum Role{
    Administrator,
    ServiceManager,
    Technician,
    ITSupport,
    Executive
}

export enum StatusRepair{
    Success,
    InWork
}