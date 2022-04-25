import { Physician } from "./physician";
import { User } from "./user";

export interface Appointment {
    appUserId: number;
    physicianId: number;
    date: Date
}