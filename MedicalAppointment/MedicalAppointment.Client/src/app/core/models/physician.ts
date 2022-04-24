import { Appointment } from "./appointment";

export interface Physician {
    firstName: string;
    lastName: string;
    gender: string;
    city: string;
    address: string;
    examPrice: number;
    speciality: string;
    imageUrl: string;
    appointments: Appointment[];
}