export interface CategoryModelServer {
    title: string,
    products: [],
    id:number
  };

  //Du lieu phan hoi cho may chu
  export interface ServerResponse  {
    count: number;
    products: CategoryModelServer[];
  };