import { DragDropContext, Droppable, Draggable, DropResult } from 'react-beautiful-dnd';
import { Box, IconButton, ListItemSecondaryAction, Typography, useTheme } from '@mui/material';
import { useEffect, useState } from 'react';
import { RepairOrder, SalesStages, StatusRepair } from '../../Type';
import dataProvider, { DataProvider } from '../../providers/dataProvider';
import Header from '../../components/Header';
import { tokens } from '../../theme';
import EditIcon from '@mui/icons-material/Edit';

interface Item {
    id: string;
    title: string;
    description: string;
}

interface Column {
    id: string;
    name: string;
    items: RepairOrder[];
}

interface KanbanProps {
    columns: Record<string, Column>;
}

function GenericKanban() {
    const [queuedOrders, setQueuedOrders] = useState<RepairOrder[]>([]);
    const [inWorkOrders, setinWorkOrders] = useState<RepairOrder[]>([]);
    const [successOrders, setSuccessOrders] = useState<RepairOrder[]>([]);
    const [changKan, setChangKan] = useState<boolean>(false);
    const [kanbanColumns, setKanbanColumns] = useState<KanbanProps>({
        columns: {
            "Queued": {
                id: 'queued',
                name: 'В очереди',
                items: [],
            },
            "InWork": {
                id: 'inWork',
                name: 'В работе',
                items: [],
            },
            "Success": {
                id: 'success',
                name: 'Выполнен',
                items: [],
            },
        },
    });
    const dataProvider: DataProvider = new DataProvider('https://localhost:7270/api');
    const [orders, setOrders] = useState<RepairOrder[]>([]);
    const [isLoading, setIsLoading] = useState<boolean>(true);
    const theme = useTheme();
    const colors = tokens(theme.palette.mode);


    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await dataProvider.getList<RepairOrder>('repairorders');
                const data = response.data || []
                //const data = await response.json();
                // setKanbanColumns((prevColumns) => ({
                //     columns: {
                //         ...prevColumns.columns,
                //         "Queued": {
                //             ...prevColumns.columns["Queued"],
                //             items: data.filter((value) => value.status === StatusRepair.Queued),
                //         },
                //         "InWork": {
                //             ...prevColumns.columns["InWork"],
                //             items: data.filter((value) => value.status === StatusRepair.InWork),
                //         },
                //         "Success": {
                //             ...prevColumns.columns["Success"],
                //             items: data.filter((value) => value.status === StatusRepair.Success),
                //         },
                //     },
                // }));
            } catch (error) {
                console.error(error);
            } finally {
                setIsLoading(false);
            }
        };
        fetchData();
    }, [changKan]);
    useEffect(() => {
        // setQueuedOrders(orders.filter((value) => value.status === StatusRepair.Queued));
        // setinWorkOrders(orders.filter((value) => value.status === StatusRepair.InWork));
        // setSuccessOrders(orders.filter((value) => value.status === StatusRepair.Success));
    }, [orders]);



    const onDragEnd = (result: DropResult) => {
        const { source, destination } = result;

        if (!destination) {
            return;
        }

        if (source.droppableId === destination.droppableId) {
            const column = kanbanColumns.columns[source.droppableId];
            const items = Array.from(column.items);
            const [removed] = items.splice(source.index, 1);
            items.splice(destination.index, 0, removed);

            setKanbanColumns({
                ...kanbanColumns,
                [source.droppableId]: {
                    ...column,
                    items: items,
                },
            });
        } else {
            const sourceColumn = kanbanColumns.columns[source.droppableId];
            const sourceItems = Array.from(sourceColumn.items);
            const [removed] = sourceItems.splice(source.index, 1);
            const destinationColumn = kanbanColumns.columns[destination.droppableId];
            const destinationItems = Array.from(destinationColumn.items);
            destinationItems.splice(destination.index, 0, removed);

            setKanbanColumns({
                ...kanbanColumns,
                [source.droppableId]: {
                    ...sourceColumn,
                    items: sourceItems,
                },
                [destination.droppableId]: {
                    ...destinationColumn,
                    items: destinationItems,
                },
            });
            removed.salesStagesId = destinationColumn.id
            // switch (destinationColumn.id) {
            //     case 'inWork': {
            //         removed.status = StatusRepair.InWork;
            //         break;
            //     }
            //     case 'queued': {
            //         removed.status = StatusRepair.Queued;
            //         break;
            //     }
            //     case 'success': {
            //         removed.status = StatusRepair.Success;
            //         break;
            //     }
            // }
            dataProvider.update<RepairOrder>('repairorders', removed.id || '0', removed)
            setChangKan(!changKan);
        }
    };

    return (
        <Box m={"20px"}>
            <Header title="Заявки" subtitle="работа с заявками" />
            {isLoading ? (
                <div>Loading...</div>
            ) : (
                <Box
                    m={"40px 0 0 0"}
                    height="75vh"
                    sx={{
                        color: colors,
                        // "& .MuiDataGrid-root": {
                        //     border: "none",
                        // },
                        // "& .MuiDataGrid-cell": {
                        //     borderBottom: "none",
                        // },
                        // "& .name-column--cell": {
                        //     color: colors.greenAccent[300],
                        // },
                        // "& .MuiDataGrid-columnHeaders": {
                        //     backgroundColor: colors.blueAccent[700],
                        //     borderBottom: "none",
                        // },
                        // "& .MuiDataGrid-virtualScroller": {
                        //     backgroundColor: colors.primary[400],
                        // },
                        // "& .MuiDataGrid-footerContainer": {
                        //     borderTop: "none",
                        //     backgroundColor: colors.blueAccent[700],
                        // },
                        // "& .MuiCheckbox-root": {
                        //     color: `${colors.greenAccent[200]} !important`,
                        // },
                    }}
                >
                    <DragDropContext onDragEnd={onDragEnd}>
                        <Box display="flex" justifyContent="center" p={2}>
                            {Object.entries(kanbanColumns.columns).map(([id, column]) => (
                                <Box
                                    sx={{ color: colors, }}
                                    key={id}
                                    p={2}
                                    //bgcolor="#F2F2F2"
                                    borderRadius={5}
                                    m={1}
                                    minWidth={300}
                                >
                                    <Typography variant="h6" gutterBottom>
                                        {column.name}
                                    </Typography>
                                    <Droppable droppableId={id} >
                                        {(provided) => (
                                            <Box ref={provided.innerRef} {...provided.droppableProps} >
                                                {column.items.map((item, index) => (
                                                    <Draggable key={item.id} draggableId={item.salesStagesId.toString()} index={index}>
                                                        {(provided) => (
                                                            <Box
                                                                sx={{ color: colors, }}
                                                                ref={provided.innerRef}
                                                                {...provided.draggableProps}
                                                                {...provided.dragHandleProps}
                                                                bgcolor="#a9a9a9"
                                                                borderRadius={5}
                                                                m={1}
                                                                p={2}
                                                            >
                                                                <Typography variant="subtitle1">{item.device ? item.device.name : ''}</Typography>
                                                                <Typography variant="body2">{item.description}</Typography>
                                                                <IconButton onClick={() => {
                                                                    document.location = 'http://localhost:5173/repairorders/' + item.id;
                                                                }} >
                                                                    <EditIcon />
                                                                </IconButton>
                                                            </Box>
                                                        )}
                                                    </Draggable>
                                                ))}
                                                {provided.placeholder}
                                            </Box>
                                        )}
                                    </Droppable>
                                </Box>
                            ))}
                        </Box>
                    </DragDropContext>
                </Box>
            )
            }
        </Box >
    );
}

function redirect(id: string) {
    document.location = 'http://localhost:5173/repairorders/' + id;
}
export function KanbanBoard() {
    const theme = useTheme();
    const colors = tokens(theme.palette.mode);
    const [isLoading, setIsLoading] = useState(true);
    const [error, setError] = useState<string | null>(null);
    const [columns, setColumns] = useState<Column[]>([
        {
            id: 'queued',
            name: 'В очереди',
            items: [],
        }, {
            id: 'inWork',
            name: 'В работе',
            items: [],
        }, {
            id: 'success',
            name: 'Выполнен',
            items: [],
        },
    ]);

function convertStatusToColumn(sourse:SalesStages):Column{
    return {
        id: sourse.id,
        name: sourse.name,
        items: sourse.orders
    }
}

    const fetchDataFromBackend = async () => {
        try {
            const response = await dataProvider.getList<RepairOrder>('repairorders');
            const status = await dataProvider.getList<SalesStages>('SalesStages');

            // if (!response.ok) {
            //     throw new Error('Failed to fetch data from the backend.');
            // }
            const dataStatus = await status.data || []
            const data = await response.data || [];

            const columns: Column[] = dataStatus.map(convertStatusToColumn);

            // [{
            //     id: 'queued',
            //     name: 'В очереди',
            //     items: data.filter((value) => value.status === StatusRepair.Queued)
            // }, {
            //     id: 'inWork',
            //     name: 'В работе',
            //     items: data.filter((value) => value.status === StatusRepair.InWork),
            // }, {
            //     id: 'success',
            //     name: 'Выполнен',
            //     items: data.filter((value) => value.status === StatusRepair.Success),
            // },]

            setColumns(columns);
            setIsLoading(false);
        } catch (error) {
            //setError(error.);
            setIsLoading(false);
        }
    };
    useEffect(() => {
        fetchDataFromBackend();
    }, []);

    const updateDataOnBackend = async (id: string, order:RepairOrder) => {
        try {
            const response = dataProvider.update<RepairOrder>('repairorders', id || '0', order)

            // if (!response.ok) {
            //     throw new Error('Failed to update data on the backend.');
            // }

            // Handle success response if needed
        } catch (error) {
            //setError(error.message);
        }
    };

    const onDragEnd = (result: DropResult) => {
        const { source, destination } = result;

        if (!destination) {
            return;
        }

        if (source.droppableId === destination.droppableId && 
            source.index === destination.index) {
            return;
        }

        if (source.droppableId === destination.droppableId) {
            const column = columns.find((column) => column.id === source.droppableId);

            if (column) {
                const items = [...column.items];
                const [removed] = items.splice(source.index, 1);
                items.splice(destination.index, 0, removed);

                const updatedColumns = columns.map((col) => col.id === source.droppableId ? { ...col, items } : col
                );

                setColumns(updatedColumns);
            }
        } else {
            const sourceColumn = columns.find((column) => column.id === source.droppableId);
            const destinationColumn = columns.find((column) => column.id === destination.droppableId);
            
            if (sourceColumn && destinationColumn) {
                const sourceItems = [...sourceColumn.items];
                const destinationItems = [...destinationColumn.items];
                const [removed] = sourceItems.splice(source.index, 1);
                destinationItems.splice(destination.index, 0, removed);

                const updatedColumns = columns.map((col) => {
                    if (col.id === source.droppableId) {
                        return { ...col, items: sourceItems };
                    }
                    if (col.id === destination.droppableId) {
                        return { ...col, items: destinationItems };
                    }
                    return col;
                });

                removed.salesStagesId = destinationColumn.id;
                // switch (destinationColumn.id) {
                //     case 'inWork': {
                //         removed.status = StatusRepair.InWork;
                //         break;
                //     }
                //     case 'queued': {
                //         removed.status = StatusRepair.Queued;
                //         break;
                //     }
                //     case 'success': {
                //         removed.status = StatusRepair.Success;
                //         break;
                //     }
                // }
                setColumns(updatedColumns);
                updateDataOnBackend(removed.id || '0', removed)
            }
        }
    };

    return (
        <DragDropContext onDragEnd={onDragEnd}>
            <Box style={{ display: 'flex', justifyContent: 'center' }}>
                {columns.map((column) => (
                    <Box key={column.id} style={{ margin: 32 }} sx={{ color: colors, }} >
                        <h2>{column.name}</h2>
                        <Droppable droppableId={column.id}>
                            {(provided) => (
                                <Box ref={provided.innerRef} {...provided.droppableProps} /*style={{ background: 'lightgrey' }}*/ sx={{ color: colors, }}>
                                    {column.items.map((item, index) => (
                                        <Draggable key={item.id} draggableId={item.salesStagesId || ''} index={index}>
                                            {(provided) => (
                                                <Box
                                                sx={{ color: colors, }}
                                                ref={provided.innerRef}
                                                {...provided.draggableProps}
                                                {...provided.dragHandleProps}
                                                bgcolor="#a9a9a9"
                                                borderRadius={5}
                                                m={1}
                                                p={2}
                                            >
                                                <Typography variant="subtitle1">{item.device ? item.device.name : ''}</Typography>
                                                <Typography variant="body2">{item.description}</Typography>
                                                <IconButton onClick={() => {
                                                    document.location = 'http://localhost:5173/repairorders/' + item.id;
                                                }} >
                                                    <EditIcon />
                                                </IconButton>
                                            </Box>
                                            )}
                                        </Draggable>
                                    ))}
                                    {provided.placeholder}
                                </Box>
                            )}
                        </Droppable>
                    </Box>
                ))}
            </Box>
        </DragDropContext>
    );
}


export default GenericKanban;