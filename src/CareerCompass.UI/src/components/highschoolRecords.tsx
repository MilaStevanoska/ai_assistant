import React from 'react';

interface Subject {
  id: string;
  name: string;
  grade: number;
}

interface YearRecord {
  year: string;
  subjects: Subject[];
}

interface HighSchoolRecordsSectionProps {
  records: YearRecord[];
}

const HighSchoolRecords: React.FC<HighSchoolRecordsSectionProps> = ({ records }) => {
  return (
    <div>
      <h3 className="text-2xl font-semibold text-gray-700 mb-2">High school records</h3>
      {records.map((yearRecord) => (
        <div key={yearRecord.year} className="mb-4 bg-gray-100 rounded-lg p-4">
          <h4 className="text-xl font-semibold text-gray-600 mb-2">{yearRecord.year}</h4>
          <div className="space-y-2">
            {yearRecord.subjects.map((subject) => (
              <div 
                key={subject.id}
                className="flex justify-between bg-gray-200 rounded py-2 px-4"
              >
                <span className="text-lg text-gray-800">{subject.name}</span>
                <span className="text-lg text-gray-800">{subject.grade}</span>
              </div>
            ))}
          </div>
        </div>
      ))}
    </div>
  );
};

export default HighSchoolRecords;