import { Guid } from "guid-typescript";

export interface Notification {
    id: string;
    text: string;
    isRead: boolean;
    createdAt: Date;
  }