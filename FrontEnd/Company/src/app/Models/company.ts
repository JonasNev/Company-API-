import { Employee } from 'src/app/Models/employee';

export interface Company {
    id?: number,
    name: string,
    employees?: Employee
}
