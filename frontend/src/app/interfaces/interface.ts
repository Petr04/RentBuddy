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
  imageLink: string,
  square: number
}

export interface User {
  userEmail: string,
  userPassword: string
}

export interface UserProfile {
  id: string,
  name: string,
  lastname: string,
  birthDate: string,
  gender: number,
  isSmoke: true,
  hasPet: true,
  communicationLevel: number,
  pureLevel: number,
  riseTime: string,
  sleepTime: string,
  timeSpentAtHome: number,
  aboutMe: string
}

export interface Room {
  apartment: Apartment;
  id: string;
  price: number;
  square: number;
  inhabitantsCount: number;
  imageLink: string;
  apartmentId: string;
  technicTypes: number[];
  furnitureTypes: number[];
  aboutRoom: string;
  isPublished: boolean;
}

export interface Apartment {
  id: string;
  roomsCount: number;
  currentFloor: number;
  maxFloor: number;
  address: string;
  isCombinedBathroom: boolean;
  bathrooomCount: number;
  technicType: number[];
  hasWifi: boolean;
  hasPassengerElevator: boolean;
  hasFreightElevator: boolean;
  parkingType: number;
  yardType: number;
  hasPet: boolean;
  canUserSmoke: boolean;
  imageLinks: string[];
  aboutApartment: string;
  ownerId: string;
}

export interface SuggestionRoom {
  roomEntity: Room;
  users: Item2;
}

export interface Item2 {
  id: string;
  name: string;
  lastname: string;
  birthDate: string;
  gender: number;
  isSmoke: boolean;
  hasPet: boolean;
  communicationLevel: number;
  pureLevel: number;
  riseTime: string;
  sleepTime: string;
  timeSpentAtHome: number;
  aboutMe: string;
  blacklistId: string;
  favoriteUsersId: string;
  favoriteRoomsId: string;
  email: string;
  passwordHash: string;
}

