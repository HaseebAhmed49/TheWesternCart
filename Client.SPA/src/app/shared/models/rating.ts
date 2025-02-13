import { Guid } from "guid-typescript";

export interface RatingDto {
    userId: string;
    username: string;
    clothingItemId: string;
    score: number;
  }