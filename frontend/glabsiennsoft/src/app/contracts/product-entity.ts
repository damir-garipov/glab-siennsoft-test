import { Entity }  from './entity'
import { EntityCollectionInfo } from './entitycollectioninfo';

export class Product implements Entity{
    code: string;
    description: string;
    price: number;
    isAvailable: boolean;
    deliveryDate: Date;
    typeDescription: string;
    unitDescription: string;
}

export class ProductCollectionInfo extends EntityCollectionInfo{
    entities: Product[];
}

export class ProductInfo{
    productDescription: string;
    price: number;
    pricePoland: string
    isAvailable: boolean;
    available: string;
    deliveryDate: Date;
    deliveryDateFormat: string;
    categoriesCount: number;
    type: string;
    unit: string;
    codeType: string;
    codeUnit: string;
    code: string;
}