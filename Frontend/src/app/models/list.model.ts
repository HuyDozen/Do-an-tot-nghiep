export interface ListModelServer{
  categoryId:number,
  nameCate:string,
  currentPage: number,
  pages:number,
  inforProducts:[{
    categoryId:number,
    categoryName:string,
    description: string,
    id: number, 
    image:string,
    images: string,
    price : number,
    quantity:number,
    shortDesc:string,
    title:string
  }],
};

export interface ListModelServerWithName{
  count:number,
  nameSearch:string ,
  currentPage: number,
  pages:number,
  inforProducts:[{
    categoryId:number,
    categoryName:string,
    description: string,
    id: number, 
    image:string,
    images: string,
    price : number,
    quantity:number,
    shortDesc:string,
    title:string
  }],
};

export interface ServerResponse {
  count: number,
  inforProducts: ListModelServer[],
}