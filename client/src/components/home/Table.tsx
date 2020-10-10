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
        var rows: Record<string, number | string | boolean>[] = [];

        for(let i = 0; i < props.data!.length; i++) {
            var row: Record<string, number | string | boolean> = {};

            if(props.data![i].id) row.id = props.data![i].id;
            else row.id = v4();

            for(let j = 0; j < props.data![i].columnNames.length; j++) {
                row[props.data![i].columnNames[j]] = props.data![i].values[j];
            }

            rows.push(row);
        }

        return rows as RowsProp;
    };

    const renderColumns = (): Columns => {
        var columns: ICol[] = [];
        var row: IData = props.data![0];

        var idColumn = returnColumnIfRowContainsId(row);
        if(idColumn) columns.push(idColumn);

        columns = [...columns, ...getColumnsFromRow(row)];
 
        return columns;
    };

    const getColumnsFromRow = (row: IData): ICol[] => {
        var columns: ICol[] = [];

        for(let i = 0; i < row.columnNames.length; i++) {
            var type = typeof row.columnNames[i];
            columns.push({ field: row.columnNames[i], headerName: row.columnNames[i], type: type, width: 150 });
        }

        return columns;
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