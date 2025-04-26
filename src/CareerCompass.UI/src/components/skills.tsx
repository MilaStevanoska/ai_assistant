import React from 'react';

interface Skill {
  name: string;
}

interface SkillsSectionProps {
  skills: Skill[];
}

const Skills: React.FC<SkillsSectionProps> = ({ skills }) => {
  return (
    <div className="mb-6">
      <h3 className="text-2xl font-semibold text-gray-700 mb-2">Skills</h3>
      <div className="flex flex-wrap gap-2">
        {skills.map((skill, index) => (
          <span
            key={index}
            className="bg-gray-200 text-gray-700 rounded-full px-3 py-1 text-lg font-medium"
          >
            {skill.name}
          </span>
        ))}
      </div>
    </div>
  );
};

export default Skills;