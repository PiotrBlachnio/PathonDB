import React, { CSSProperties, ReactElement } from 'react';
import { DataGrid } from '@material-ui/data-grid';
import { IData } from './index';
import { v4 } from 'uuid';

interface IProps {
    isOpen: boolean;
    data: IData[] | null;
}

const style: CSSProperties = {
    height: 400,
    width: 1000,
    position: 'absolute',
    bottom: '0%',
    left: '50%',
    transform: 'translate(-50%)'
};

// TODO: Do refactoring

const Table: React.FC<IProps> = (props): ReactElement => {
    const renderRows = (): any => {
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

        return rows;
    };

    const renderColumns = (): any => {
        var columns: Record<string, string | number>[] = [];

        if(props.data![0].id) columns.push({ field: 'id', headerName: 'ID', width: 320 });

        for(let i = 0; i < props.data![0].columnNames.length; i++) {
            var type = typeof props.data![0].columnNames[i];
            columns.push({ field: props.data![0].columnNames[i], headerName: props.data![0].columnNames[i], type: type, width: 150 });
        }
        
        return columns;
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