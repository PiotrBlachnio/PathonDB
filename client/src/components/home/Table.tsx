import React, { ReactElement } from 'react';
import { DataGrid, RowProps } from '@material-ui/data-grid';
import { IData } from './index';
import { v4 } from 'uuid';

interface IProps {
    isOpen: boolean;
    data: IData[] | null;
}

const columns = [
    { field: 'id', headerName: 'ID'},
    { field: 'firstName', headerName: 'First name' },
    { field: 'lastName', headerName: 'Last name' },
    {
      field: 'age',
      headerName: 'Age',
      type: 'number'
    }
  ];
  
  const rows = [
    { id: 1, lastName: 'Snow', firstName: 'Jon', age: 35 },
    // { id: 2, lastName: 'Lannister', firstName: 'Cersei', age: 42 },
    // { id: 3, lastName: 'Lannister', firstName: 'Jaime', age: 45 },
    // { id: 4, lastName: 'Stark', firstName: 'Arya', age: 16 },
    // { id: 5, lastName: 'Targaryen', firstName: 'Daenerys', age: null },
    // { id: 6, lastName: 'Melisandre', firstName: null, age: 150 },
    // { id: 7, lastName: 'Clifford', firstName: 'Ferrara', age: 44 },
    // { id: 8, lastName: 'Frances', firstName: 'Rossini', age: 36 },
    // { id: 9, lastName: 'Roxie', firstName: 'Harvey', age: 65 },
  ];

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
                <div style={{ height: 400, width: 1000, position: 'absolute', bottom: 0 }}>
                    <DataGrid rows={renderRows()} columns={renderColumns()} pageSize={5} checkboxSelection />
                </div>
            : null }
        </>
    );
}

export default Table;