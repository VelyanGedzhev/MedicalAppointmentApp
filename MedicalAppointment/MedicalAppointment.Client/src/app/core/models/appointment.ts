import { Physician } from "./physician";
import { User } from "./user";

export interface Appointment {
    UserId: number;
    user: User;
    physicianId: number;
    physician: Physician;
    date: Date,
    hour: string
}