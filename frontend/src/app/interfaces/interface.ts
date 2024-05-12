export interface FilterRent{
  city:string | null,
  inhabitantsCount?: number,
  square?: number,
  minPrice?: number,
  maxPrice?: number
}


export interface Post{
  apartment: {
    id: string,
    roomsCount: number,
    currentFloor: number,
    maxFloor: number,
    address: string
  },
  apartmentId: string,
  id: string,
  inhabitantsCount: number,
  price: number,
  square: number
}

export interface User {
  id: number;
  picture: string;
  age: number;
  name: string;
  gender: string;
}
