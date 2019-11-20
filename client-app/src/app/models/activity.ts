// Created for type checking, interface does not get transpiled to javascript like class

export interface IActivity {
    id: string;
    title: string;
    description: string;
    category: string;
    date: Date;
    city: string;
    venue: string;
}