export class Product {
    public laptopModel?: string;
    public hardDriveSize: string;
    public screenSize: number;
    public hardDrive: HardDriveType;
    public processor: ProcessorType;
    public productId: number;
    public title: string;
    public price: number;
    public condition: ConditionType;
    public quantity: number;
    public discriminator: Discriminator;
    public productImages?: string;
    public productReviews?: any;
    public avgCustomerReview: number;
    public isAvailiable: boolean;
    public subDepartmentId: number;

    constructor() {
    }
}

enum Discriminator {
    unKnown,
    Laptop,
    Phone,
}


enum ConditionType {
    unKnown,
    New,
    Used,
    Refurbished
}

enum ProcessorType {
    unKnown,
    IntelI5,
    IntelI3,
    IntelI7,
    AMD

}


enum HardDriveType {
    unKnown,
    HHD,
    SSD,
    Hybrid
}

