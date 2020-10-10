import React, { CSSProperties, ReactElement } from 'react';
import { Columns, DataGrid, RowsProp } from '@material-ui/data-grid';
import { IData } from './index';
import { v4 } from 'uuid';

interface IProps {
    isOpen: boolean;
    data: IData[] | null;
}

interface ICol {
    field: string;
    headerName?: string;
    width?: number;
    type?: string;
}

const style: CSSProperties = {
    height: 400,
    width: 1000,
    position: 'absolute',
    bottom: '0%',
    left: '50%',
    transform: 'translate(-50%)'
};

const Table: React.FC<IProps> = (props): ReactElement => {
    const renderRows = (): RowsProp => {
        const rows: RowsProp = getRowsFromData()

        return rows;
    };

    const renderColumns = (): Columns => {
        let columns: ICol[] = [];
        const row: IData = props.data![0];

        const idColumn = returnColumnIfRowContainsId(row);
        if(idColumn) columns.push(idColumn);

        columns = [...columns, ...getColumnsFromRow(row)];
 
        return columns;
    };

    const getColumnsFromRow = (row: IData): ICol[] => {
        const columns: ICol[] = [];

        for(let i = 0; i < row.columnNames.length; i++) {
            const type = typeof row.columnNames[i];
            columns.push({ field: row.columnNames[i], headerName: row.columnNames[i], type: type, width: 150 });
        }

        return columns;
    };

    const getRowsFromData = (): RowsProp => {
        const rows = [];

        for(let i = 0; i < props.data!.length; i++) {
            const currentDataElement = props.data![i];
            const row: Record<string, number | string | boolean> = {};

            row.id = currentDataElement.id ? currentDataElement.id : v4();

            for(let j = 0; j < currentDataElement.columnNames.length; j++) {
                row[currentDataElement.columnNames[j]] = currentDataElement.values[j];
            }

            rows.push(row);
        }

        return rows as RowsProp;
    };

    const returnColumnIfRowContainsId = (row: IData): ICol | null => {
        if(!row.id) return null;

        return { field: 'id', headerName: 'ID', width: 320 };
    };

    return (
        <>
            { props.isOpen ? 
                <div style={style}>
                    <DataGrid rows={renderRows()} columns={renderColumns()} pageSize={5} checkboxSelection />
                </div>
            : null }
        </>
    );
}

export default Table;