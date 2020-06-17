export class MetricResponse {
    metrics: IMetric[];
}

export interface IMetric {
    title: string;
    value: IValueDTO;
}

export interface IValueDTO {
    count?: string;
    compose?: IComposeValueDTO[];
}

export interface IComposeValueDTO {
    text: string;
    count: string;
}
