import React, { useState } from 'react';
import axios from 'axios';

const SearchField = () => {
    const [requiredSkills, setRequiredSkills] = useState({
        AutoCAD: 0,
        'Autodesk Inventor': 0,
        OpenCascade: 0,
        'Three.js': 0,
        Eyeshot: 0,
        HOOPS: 0,
        JavaScript: 0,
        'C#': 0,
        Python: 0,
        React: 0,
        'Node.js': 0,
        'ASP.NET': 0,
        Unity: 0,
        'Unreal Engine': 0,
        Revit: 0,
        Navisworks: 0,
    });

    const [experienceLevel, setExperienceLevel] = useState('Junior');
    const [availability, setAvailability] = useState('Available');
    const [results, setResults] = useState([]);
    const [loading, setLoading] = useState(false);

    const handleSkillChange = (e) => {
        setRequiredSkills({
            ...requiredSkills,
            [e.target.name]: parseInt(e.target.value),
        });
    };

    const handleSubmit = () => {
        const requestData = {
            requiredSkills: requiredSkills,
            experienceLevel: experienceLevel,
            availability: availability,
        };

        setLoading(true);

        axios
            .post('http://localhost:5129/Match', requestData)
            .then((res) => {
                setResults(res.data);
                setLoading(false);
            })
            .catch((err) => {
                console.error('Error calling Match API:', err);
                setLoading(false);
            });
    };

    return (
        <div className="container mt-4">
            <h2>Search Employee Match</h2>

            <div className="row mb-3">
                {Object.keys(requiredSkills).map((skill) => (
                    <div className="col-md-3 mb-3" key={skill}>
                        <label className="form-label">{skill}</label>
                        <select
                            className="form-select"
                            name={skill}
                            value={requiredSkills[skill]}
                            onChange={handleSkillChange}
                        >
                            <option value="0">None</option>
                            <option value="1">Beginner</option>
                            <option value="2">Intermediate</option>
                            <option value="3">Expert</option>
                        </select>
                    </div>
                ))}
            </div>

            <div className="row mb-3">
                <div className="col-md-6">
                    <label className="form-label">Experience Level</label>
                    <select
                        className="form-select"
                        value={experienceLevel}
                        onChange={(e) => setExperienceLevel(e.target.value)}
                    >
                        <option value="Junior">Junior</option>
                        <option value="Mid">Mid</option>
                        <option value="Senior">Senior</option>
                    </select>
                </div>
                <div className="col-md-6">
                    <label className="form-label">Availability</label>
                    <select
                        className="form-select"
                        value={availability}
                        onChange={(e) => setAvailability(e.target.value)}
                    >
                        <option value="Available">Available</option>
                        <option value="Unavailable">Unavailable</option>
                        <option value="Partially Available">Partially Available</option>
                    </select>
                </div>
            </div>

            <button className="btn btn-primary mb-4" onClick={handleSubmit}>
                Match Employees
            </button>

            {loading && <p>Loading results...</p>}

            {!loading && results.length > 0 && (
                <div>
                    <h4>Matching Results:</h4>
                    <table className="table table-bordered">
                        <thead>
                            <tr>
                                <th>Employee ID</th>
                                <th>Name</th>
                                <th>Score</th>
                            </tr>
                        </thead>
                        <tbody>
                            {results.map((emp, index) => (
                                <tr key={index}>
                                    <td>{emp.employeeId}</td>
                                    <td>{emp.name}</td>
                                    <td>{emp.matchScore}</td>
                                </tr>
                            ))}
                        </tbody>
                    </table>
                </div>
            )}
        </div>
    );
};

export default SearchField;
