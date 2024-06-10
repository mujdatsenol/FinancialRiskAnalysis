import React, { useEffect, useState } from 'react';

const BusinessTopicList = () => {
    const host = 'http://localhost:5019/api/BusinessTopic/';
    const [businessTopics, setBusinessTopics] = useState([]);
    const [form, setForm] = useState({
        title: '',
        description: '',
        pageIndex: 1,
        pageNumber: 1,
        pageSize: 20
    });
    const [businessTopic, setBusinessTopic] = useState({
        title: '',
        description: '',
        starDate: '',
        endDate: ''
    });

    const handleChange = (event) => {
        setForm({
          ...form,
          [event.target.id]: event.target.value,
        });
    };

    const handleSubmit = (event) => {
        event.preventDefault();
        fetchData();
    };

    const fetchData = async () => {
        await fetch(host + 'search',
        {
            method: 'POST',
            mode: 'cors',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(form)
        })
        .then(response => response.json())
        .then(response => {
            if (!response.isSuccessful) {
                var errorMessage = response.error != null
                    ? response.error
                    : "İş konusu listesi getirilirken bir hata meydana geldi";

                alert(errorMessage);
            }

            setBusinessTopics(response.result.pagedList);
        })
        .catch(error => {
            console.log(error);
            alert("İş konusu listesi getirilirken bir hata meydana geldi");
        });
    }

    const UpdateButton = ({ onClick }) => {
        return (
            <button
                type="button"
                className="btn btn-primary btn-sm"
                data-bs-toggle="modal"
                data-bs-target="#updateModal"
                onClick={onClick}>Güncelle</button>
        )
    }

    const getBusinessTopicForSet = (businessTopic) => {
        setBusinessTopic(s => ({
            ...s,
            businessTopicId: businessTopic.id,
            title: businessTopic.title,
            description: businessTopic.description,
            starDate: businessTopic.starDate,
            endDate: businessTopic.endDate
        }));
    }

    const handleSetChange = (event) => {
        setBusinessTopic({
          ...businessTopic,
          [event.target.id]: event.target.value,
        });
    };

    const handleSetSubmit = (event) => {
        event.preventDefault();
        putSetData();
    };

    const putSetData = async () => {
        await fetch(host + businessTopic.businessTopicId,
        {
            method: 'PUT',
            mode: 'cors',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(businessTopic)
        })
        .then(response => response.json())
        .then(response => {
            if (!response.isSuccessful) {
                var errorMessage = response.error != null
                    ? response.error.message
                    : "İş konusu güncellenirken bir hata meydana geldi";

                alert(errorMessage);
            } else {
                alert("Güncelleme işlemi başarılı")
                fetchData();
            }
        })
        .catch(error => {
            console.log(error);
            alert("İş konusu güncellenirken bir hata meydana geldi");
        });
    }

    useEffect(() => 
    {
        fetchData();
    }, []);

    return(
        <div className='container'>
            <div className='row mt-3'>
                <div className='col'>
                    <form onSubmit={handleSubmit} className="row">
                        <div className="col-3">
                            <input
                                id="title"
                                type="text"
                                className="form-control"
                                placeholder="İş Konusu Adı"
                                value={form.title}
                                onChange={handleChange} />
                        </div>
                        <div className="col-3">
                            <input
                                id="description"
                                type="text"
                                className="form-control"
                                placeholder="Açıklama"
                                value={form.description}
                                onChange={handleChange} />
                        </div>
                        <div className='col-3 d-grid'>
                            <button type="submit" className="btn btn-primary mb-3">Filtrele</button>
                        </div>
                    </form>
                    <table className="table table-striped table-hover table-bordered ">
                        <thead className='table-dark'>
                            <tr>
                                <th></th>
                                <th>İş Adı</th>
                                <th>Açıklama</th>
                                <th>Başlama</th>
                                <th>Bitiş</th>
                                <th>Oluşturulma</th>
                                <th>Güncelleme</th>
                            </tr>
                        </thead>
                        <tbody>
                            {businessTopics.map(businessTopic =>
                                <tr key={businessTopic.id}>
                                    <td style={{textAlign: 'center'}}>
                                        <UpdateButton onClick={() => getBusinessTopicForSet(businessTopic)}></UpdateButton>
                                    </td>
                                    <td>{businessTopic.title}</td>
                                    <td>{businessTopic.description}</td>
                                    <td>{businessTopic.starDate}</td>
                                    <td>{businessTopic.endDate}</td>
                                    <td>{businessTopic.createDate}</td>
                                    <td>{businessTopic.updateDate}</td>
                                </tr>)}
                        </tbody>
                    </table>
                    
                    <div className="modal fade" id="updateModal" aria-labelledby="updateModalLabel" aria-hidden="true">
                        <div className="modal-dialog">
                            <div className="modal-content">
                                <div className="modal-header">
                                    <h1 className="modal-title fs-5" id="updateModalLabel">İş Konusu Güncelle</h1>
                                    <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>
                                <div className="modal-body">
                                    <form onSubmit={handleSetSubmit} >
                                        <input
                                            id="id"
                                            type="hidden"
                                            className="form-control"
                                            value={businessTopic.id} />
                                        <div className="mb-3">
                                            <label htmlFor='title' className="form-label">İş Konusu</label>
                                            <input
                                                id="title"
                                                type="text"
                                                className="form-control"
                                                value={businessTopic.title}
                                                onChange={handleSetChange} />
                                            <label htmlFor='title' className="form-label">Açıklaması</label>
                                            <input
                                                id="description"
                                                type="text"
                                                className="form-control"
                                                value={businessTopic.description}
                                                onChange={handleSetChange} />
                                        </div>
                                    </form>
                                </div>
                                <div className="modal-footer">
                                    <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">Kapat</button>
                                    <button type="button" className="btn btn-primary" onClick={handleSetSubmit.bind(this)}>Güncelle</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    
                </div>
            </div>
        </div>
    )
};

export default BusinessTopicList;